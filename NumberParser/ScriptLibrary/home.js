function submitData() {
    var url = "/api/values/SubmitValues";
    var userDetails = {
        Name: $('#Name').val(),
        Number: $('#Amount').val(),      
    };
    $.ajax({
        type: "POST",
        url: url,
        data: userDetails,
        success: function (data) {
            var name = data.Name;
            var numberText = data.NumberInWords;
            $("#NameText").html(name);
            $("#AmountText").html(numberText);
        },
        error: function () {
            alert("Ajax call failed");
        },
    });
}
