// Dont  change this:
function BindDropdown(result, ControlId, ValueField, TextField, price) {
    var optionhtml = null;
    $(ControlId).find('option').remove();
    if (result.length > 0) {
        optionhtml += '<option value="0>Select</option>';
        for (var i = 0; i < result.length; i++) {
            optionhtml = '<option data-price" ' + result[i][price] + '" value="' +
                result[i][ValueField] + '">' + result[i][TextField] + '</option>';
            $(ControlId).append(optionhtml);
        }
    }
    else {
        var myOptions = {
            val1: '(Not Available)',
        };
        var mySelect = $(ControlId);
        $.each(myOptions, function (val, text) {
            mySelect.append(
                $('<option></option>').val(val).html(text)
            );
        });
    }
}
//For bind the complaints with price
function BindDropdown1(result, ControlId, ValueField, TextField, price) {
    var optionhtml = null;
    $(ControlId).find('option').remove();
    if (result.length > 0) {
        for (var i = 0; i < result.length; i++) {
            optionhtml = '<option value="' +
                result[i][ValueField] + '">' + result[i][TextField] + -result[i][price] + '</option>';
            $(ControlId).append(optionhtml);
        }
    }
    else {
        var myOptions = {
            val1: '(Not Available)',
        };
        var mySelect = $(ControlId);
        $.each(myOptions, function (val, text) {
            mySelect.append(
                $('<option></option>').val(val).html(text)
            );
        });
    }
}
// To This to find total price with gst and to show the values in grid table
function Price() {
    $('#divgst').show();
    var Above1000 = parseInt($('#Above1000').val());
    var Less1000 = parseInt($('#Less1000').val());
    var complaintlist = "", complainttext = [] /*, complaintvalue = []*/;
    // This array is for find price with gst
    var str = [], GST = [], Price = [];
    $("#complaintdropdown option:selected").each(function () {
        complainttext.push($(this).text());
        //complaintvalue.push($(this).val());
        str.push($(this).text().split('-')[1]);
    });
    // By that array looping and adding the values
    for (var i = 0; i < str.length; i++) {
        var Gstprice = 0;
        if (str[i] > 999) {
            // This is only for to find only above 1000 pertecage
            Gstprice = str[i] * Above1000 / 100;
            GST.push(str[i] * Above1000 / 100);

        }
        else if (str[i] < 1000) {
            // This is only for to find only less 1000 pertecage
            Gstprice = str[i] * Less1000 / 100;
            //If use this gst in add it get concate so that using gst price variable
            GST.push(str[i] * Less1000 / 100);
        }
        Price.push(Gstprice + parseInt(str[i]) << 0);
    }
    //This is for bind table with those values
    for (var i = 0; i < complainttext.length; i++) {
        complaintlist += '<tr>'
            + '<td>' + complainttext[i] + '</td>'
            + '<td>' + GST[i] + '</td>'
            + '<td>' + Price[i] + '</td>'
        '</tr>'
    }
    //To show tbl complaint
    $('#tblcomplaint').show();
    //To empty tbl complaint grid
    $('#tblcomplaint').find('tbody').empty();
    //Append the value to that grid
    $('#tblcomplaint').find('tbody').append(complaintlist);
    //This is to find the gst total price
    var gstTotal = 0;
    for (var i = 0; i < GST.length; i++) {
        gstTotal += GST[i];
    }
    //To show that finded value in label
    $('#lblgsttotal').text(gstTotal);
    // This array is for find price with gst
    var str = [];
    $("#complaintdropdown option:selected").each(function () {
        //Split by - and push to Array
        str.push($(this).text().split('-')[1]);
    });
    var total = 0, sum = 0;
    // By that array looping and adding the values
    for (var i = 0; i < str.length; i++) {
        if (str[i] > 999) {
            // This is only for to find only 24 pertecage
            sum = str[i] * Above1000 / 100 + parseInt(str[i]) << 0;
        }
        else if (str[i] < 1000) {
            // This is only for to find only 18 pertecage
            var sum = str[i] * Less1000 / 100 + parseInt(str[i]) << 0;
        }
        total += sum << 0;
    }
    // Finally showing in Textbox
    $("#TotalPrice").val(total);

}