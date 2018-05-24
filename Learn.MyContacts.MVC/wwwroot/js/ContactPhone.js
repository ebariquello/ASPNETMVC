
var ContactPhone = {

    ValidateOnUpdateInsert: function (contactID, phoneType, operation, isUpdate) {
        $.ajax({
            url: "/ContactPhone/GetContactPhoneByContactID/" + contactID,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var exists = false;
                if (isUpdate===false) {
                    $.each(result, function (key, item) {
                        if (item.phoneType == phoneType) {
                            exists = true;
                        }
                    });
                }
                if (ContactPhone.ValidateFields(exists)== true);
                {
                    operation();
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);

            }
        });
    },
    //Load Data function
    ReloadContactPhone: function (contactID) {
        $.ajax({
            url: "/ContactPhone/GetContactPhoneByContactID/" + contactID,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '<tr><th>Telefone</th><th>Tipo</th></tr>';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.phone + '</td>';
                    html += '<td>' + item.phoneType == "0" ? "Casa" : (item.phoneType == "1"? "Trabalho" : "Outros") + '</td>';
                    html += '<td><a href="#" onclick="return ContactPhone.GetContactPhoneByID(' + item.contactID + ',' + item.contactPhoneID + ')">Editar</a> | <a href="#" onclick="Delele(' + item.contactID + ',' + item.contactPhoneID + ')">Deletar</a></td>';
                    html += '</tr>';
                });
                $('#tablePhone').html('');
                $('#tablePhone').html(html);
                $('#myContactPhoneModal').modal('hide');
                $('#Phone').val("");
                $('#PhoneType').val("");
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    },
    GetContactPhoneByID: function (contactID, contactPhoneID) {

        $.ajax({
            url: "/ContactPhone/GetContactPhoneByID/" + contactPhoneID,
            typr: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $('#ContactPhoneID').val(result.contactPhoneID);
                $('#ContactPhoneContactID').val(result.contactID);
                $('#Phone').val(result.phone);
                $('#PhoneType').val(result.phoneType);
                $('#PhoneType').prop("disabled", true); 
                $('#myContactPhoneModal').modal('show');
                $('#btnUpdateContatPhone').show();
                $('#btnAddContactPhone').hide();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
        return false;
    },
    Add: function () {
        
        ContactPhone.ValidateOnUpdateInsert($('#ContactPhoneContactID').val(), $('#PhoneType').val(), function () {

            var cp = {
                ContactID: $('#ContactPhoneContactID').val(),
                Phone: $('#Phone').val(),
                PhoneType: $('#PhoneType').val(),
            };
            $.ajax({
                url: "/ContactPhone/Save",
                data: JSON.stringify(cp),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    ContactPhone.ReloadContactPhone(result.contactID);
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            }, false);
        }
        );
    },
   
    
    //function for updating employee's record
    Update: function () {
        ContactPhone.ValidateOnUpdateInsert($('#ContactPhoneContactID').val(), $('#PhoneType').val(), function () {
            var cp = {
                ContactID: $('#ContactPhoneContactID').val(),
                ContactPhoneID: $('#ContactPhoneID').val(),
                Phone: $('#Phone').val(),
                PhoneType: $('#PhoneType').val(),
            };
            $.ajax({
                url: "/ContactPhone/Save",
                data: JSON.stringify(cp),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    ContactPhone.ReloadContactPhone(result.contactID);
                  
          
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }, true
        );
    },
    Delete: function (contactID, contactPhoneID) {
        var ans = confirm("Tem certeza que deseja remover este número do contato?");
        if (ans) {
            $.ajax({
                url: "/ContactPhone/Delete/" + contactPhoneID,
                type: "DELETE",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    ContactPhone.ReloadContactPhone(contactID);
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }
    },
    //Function for clearing the textboxes
    ClearContactPhoneTextBox: function (contatctID) {
        $('#ContactPhoneContactID').val(contatctID);
        $('#ContactPhoneID').val("");
        $('#Phone').val("");
        $('#PhoneType').val("");
        $('#PhoneType').prop("disabled", false); 
        $('#btnUpdateContatPhone').hide();
        $('#btnAddContatPhone').show();
        $('#Phone').css('border-color', 'lightgrey');
        $('#PhoneType').css('border-color', 'lightgrey');

    },
    //Valdidation using jquery
    ValidateFields: function (phoneTypeAlreadyExists) {
        var isValid = true;
        if ($('#Phone').val().trim() == "") {
            $('#Phone').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Phone').css('border-color', 'lightgrey');
        }
        if ($('#PhoneType').val().trim() == "") {
            $('#PhoneType').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#PhoneType').css('border-color', 'lightgrey');
        }
        if (phoneTypeAlreadyExists== true) {
            $('#PhoneType').css('border-color', 'Red');
            $('#PhoneType').val("");
            $("#errorMsgPhoneType").html("Tipo de Telefone já selecionado").show().fadeOut("slow");
            isValid = false;
        }
        else {
            $('#PhoneType').css('border-color', 'lightgrey');
        }
        return isValid;
    }

};