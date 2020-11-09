function InvalidMsg(textbox) {
    
    if (textbox.value == '') {
        textbox.setCustomValidity('Ingresa el nombre de usuario');
    }
    else if(textbox.validity.typeMismatch){
        textbox.setCustomValidity('Ingresa un nombre de usuario válido');
    }
    else {
        textbox.setCustomValidity('');
    }
    return true;
}

function InvalidPass(textbox) {
    
    if (textbox.value == '') {
        textbox.setCustomValidity('Ingresa la contraseña');
    }
    else if(textbox.validity.typeMismatch){
        textbox.setCustomValidity('Ingresa una contraseña válida');
    }
    else {
        textbox.setCustomValidity('');
    }
    return true;
}