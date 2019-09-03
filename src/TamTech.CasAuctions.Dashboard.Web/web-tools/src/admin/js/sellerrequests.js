const CreateTables = (data)=>{
    let result = '';

    data.forEach((item)=>{
        let _date='';
        if(item.date !== null){
            let d = new Date(item.date);
            _date = `${d.getFullYear()}/${d.getMonth()}/${d.getDay()}`;
        }
        result += `
        <tr>
            <td dir="ltr" class="text-center">${_date}</td>
            <td><span>${item.previous_status_name !== null ? item.previous_status_name : '' }</span> </td>
            <td><span>${item.action_name}</span> </td>
            <td><span>${item.current_status_name}</span></td>
            <td><span>${item.notes}</span></td>
        </tr>
        `
    })
    return result;
}

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
                     $('#request_status').text(_data.statusName);
                     $('#request_status').removeClass().addClass(`badge badge-${_data.status_options}`);
                      if(_data.histories){
                        $( "#history" ).html(  CreateTables(_data.histories)  )
                     }
                    setTimeout(()=>{
                        $('a[href="#history"]').click();
                        $('#history').addClass('active in');
                        $('a[href="#form"]').parent().remove();
                        $('#form').remove();  
                    },500) 
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