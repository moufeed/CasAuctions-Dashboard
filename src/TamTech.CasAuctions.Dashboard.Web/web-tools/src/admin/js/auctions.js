$(document).ready(()=>{

 
    $('#takenAction').validate({
        errorClass: "invalid_field",
        validClass: "valid_field",
        ignore: ".ignore",
        errorPlacement: function (error, element) {
            if (element.attr('name') == 'ActionId') {
                error.appendTo('.actionId-errors');
                return;
            }  else {
                error.insertAfter(element);
            }
        },
        submitHandler:function(form){
            let action = $(form).attr("action");

            $.ajax({
                url: action ,
                type: "POST",
                data: $(form).serialize(),
                cache: false,
                processData: false,
                success: function(data) {
                    console.log(data)
                    if(data.success){
                        let _data = data.result.data;
                        $('#takenAction').trigger("reset");
                        $notification.success("",window.localization.processed_successfully, 2000, "fa fa-check");
                        setTimeout(()=>window.location.reload() ,1500)
    /*
                         $('#request_status').text(_data.status_name);
                         $('#request_status').removeClass().addClass(`badge badge-${_data.status_options}`);
                          if(_data.histories){
                            $( "#historytable tbody" ).html(  CreateTables(_data.histories)  )
                         }
                        setTimeout(()=>{
                            $('a[href="#history"]').click();
                            $('#history').addClass('active in');
                            $('a[href="#form"]').parent().remove();
                            $('#form').remove();
                        },500)  */
                    }else{
                        var errors = data.errors;
                        if (errors.length > 0) {
                        let txt = MakeErrorsMsg(errors);
                            $notification.error("", txt , 3500, "fa fa-exclamation-circle");
                        }
                    }
                }
            });
            return false;
        }
    })

    })