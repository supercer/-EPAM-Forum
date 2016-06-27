(function () {
    var new_section = document.getElementById("NewSection");
    var new_topic = document.getElementById("NewTopic");
    var new_message = document.getElementById("NewMessage");

    var count = 0;

    if (new_topic != null) {
        new_topic.onclick = function () {
            count++;
            if (count == 1) {
                $('#NewTopicContainer').append('<input id="Name" type="text" name="Name" />');
                $('#NewTopicContainer').append('<button>Создать</button>');
            }
        }
    }

    if (new_message != null) {
        new_message.onclick = function () {
            count++;
            if (count == 1) {
                $('#NewMessageContainer').append('<textarea id="Text" type="text" name="Text"> </textarea>');
                $('#NewMessageContainer').append('<button>Отправить</button>');
            }
        }
    }

    if (new_section != null) {
        new_section.onclick = function () {
            count++;
            if (count == 1) {
                $('#NewSectionContainer').append('<input id="Name" type="text" name="Name" />');
                $('#NewSectionContainer').append('<button>Создать</button>');
            }
        }
    }
})();

(function passcorr() {
    var p = /^[a-zA-Z0-9]+$/;
  
    document.getElementById("Password").oninput = function inspectionParol() {
        var password = document.getElementById("Password").value;
        var err;
        if (password.length >= 6 && password.length <= 20)
        {
            err = "<font color='green'>Верная длина.</font>";
        }
        else {
            err = "<font color='red'>Пароль неверной длины. Пароль должен быть не менее 6 и не более 20 символов!</font>";
        }
        
        if (p.test(password))
        {
            err += "<font color='green'> Введены допустимые символы.</font>";
        }
        else {
            err += "<font color='red'> Введены недопустимые символы! Разрешены только латинские буквы и цифры!</font>";
        }

        
        document.getElementById("RepeatPassword").oninput = function () {
            var err2 = "<font color='red'>Пароли не совпадают!</font>";
            var repeatPassword = document.getElementById("RepeatPassword").value;
            if (password == repeatPassword) {
                err2 = "<font color='green'> Пароли совпадают.</font>";
            }
            else {
                if (err2 != "<font color='red'>Пароли не совпадают!</font>") {
                    err2 += "<font color='red'>Пароли не совпадают!</font>";
                }
            }

            document.getElementById("error2").innerHTML = err2;
        }
        document.getElementById("error").innerHTML = err;
    }
})();