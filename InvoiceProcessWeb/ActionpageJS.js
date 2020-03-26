
function addRow(tableID) {
    debugger;
    var table = document.getElementById(tableID);
    var rowval = [
        ($("#tvalue").val() != '' ? $("#tvalue").val() : 0),
        ($("#igst").val() != '' ? $("#igst").val() : 0),
        ($("#sgst").val() != '' ? $("#sgst").val() : 0),
        ($("#cgst").val() != '' ? $("#cgst").val() : 0),
        ($("#utgst").val() != '' ? $("#utgst").val() : 0),
        ($("#cess").val() != '' ? $("#cess").val() : 0),
        ($("#total").val() != '' ? $("#total").val() : 0)
    ];
    var tabcontent = table.innerHTML;
    var str = "<tr>"
    str = str + "<td><input type='hidden' name='itemname' value='" + $("#itemname").val() + "' />" + $("#itemname").val() + "</td>" +
        "<td><input type='hidden' name='hsn' value='" + $("#hsn").val() + "' />" + $("#hsn").val() + "</td>" +
        "<td><input type='hidden' name='uom' value='" + $("#uom").val() + "' />" + $("#uom").val() + "</td>" +
        "<td><input type='hidden' name='qty' value='" + $("#qty").val() + "' />" + $("#qty").val() + "</td>" +
        "<td><input type='hidden' name='rpu' value='" + $("#rpu").val() + "' />" + $("#rpu").val() + "</td>" +
        "<td><input type='hidden' name='tvalue' value='" + $("#tvalue").val() + "' />" + $("#tvalue").val() + "</td>" +
        "<td><input type='hidden' name='rate' value='" + $("#rate").val() + "' />" + $("#rate").val() + "</td>" +
        "<td><input type='hidden' name='igst' value='" + $("#igst").val() + "' />" + $("#igst").val() + "</td>" +
        "<td><input type='hidden' name='sgst' value='" + $("#sgst").val() + "' />" + $("#sgst").val() + "</td>" +
        "<td><input type='hidden' name='cgst' value='" + $("#cgst").val() + "' />" + $("#cgst").val() + "</td>" +
        "<td><input type='hidden' name='utgst' value='" + $("#utgst").val() + "' />" + $("#utgst").val() + "</td>" +
        "<td><input type='hidden' name='cess' value='" + $("#cess").val() + "' />" + $("#cess").val() + "</td>" +
        "<td><input type='hidden' name='total' value='" + $("#total").val() + "' />" + $("#total").val() + "</td>" +
        " <td><a value='Delete' onclick='deleteRow(this," + rowval + ")' style='color:white' class='btn btn-sm btn-danger'><b><i class='glyphicon glyphicon-trash'></i></b></a></td></tr>";

    $("#taxVAlTotal").val(parseFloat($("#taxVAlTotal").val()) + parseFloat(rowval[0]));
    $("#tigst").val(parseFloat($("#tigst").val()) + parseFloat(rowval[1]));
    $("#tsgst").val(parseFloat($("#tsgst").val()) + parseFloat(rowval[2]));
    $("#tcgst").val(parseFloat($("#tcgst").val()) + parseFloat(rowval[3]));
    $("#tutgst").val(parseFloat($("#tutgst").val()) + parseFloat(rowval[4]));
    $("#tcess").val(parseFloat($("#tcess").val()) + parseFloat(rowval[5]));
    $("#Gtotal").val(parseFloat($("#Gtotal").val()) + parseFloat(rowval[6]));
    if (table.rows.length == 0) {
        table.innerHTML = str;
    }
    else {
        table.innerHTML = tabcontent + str;
    }
    Reset();
}

function Reset() {
    $("#itemname").val('');
    $("#hsn").val('');
    $("#uom").val('');
    $("#qty").val('');
    $("#rpu").val('');
    $("#tvalue").val('');
    $("#rate").val('');
    $("#igst").val('');
    $("#sgst").val('');
    $("#cgst").val('');
    $("#utgst").val('');
    $("#cess").val('');
    $("#total").val('');

}
function deleteRow(row, taxval, igst, sgst, cgst, utgst, cess, total) {
    debugger
    var table = document.getElementById("itemDt");
    var rowCount = table.rows.length;
    if (rowCount > 0) {
        var rowIndex = row.parentNode.parentNode.rowIndex;
        document.getElementById("itemDt").deleteRow(rowIndex - 2);
        $("#taxVAlTotal").val(parseFloat($("#taxVAlTotal").val()) - parseFloat(taxval));
        $("#tigst").val(parseFloat($("#tigst").val()) - parseFloat(igst));
        $("#tsgst").val(parseFloat($("#tsgst").val()) - parseFloat(sgst));
        $("#tcgst").val(parseFloat($("#tcgst").val()) - parseFloat(cgst));
        $("#tutgst").val(parseFloat($("#tutgst").val()) - parseFloat(utgst));
        $("#tcess").val(parseFloat($("#tcess").val()) - parseFloat(cess));
        $("#Gtotal").val(parseFloat($("#Gtotal").val()) - parseFloat(total));
    }
    else {
        alert("No rows to delete!!.");
    }
}


function RateEntered(x) {
    debugger
    var utarr = ["04", "25", "26", "35", "38", "97"];
    if ($("#tvalue").val() != '' && $("#partygst").val() != '') {
        if (x.value != '') {
            var gst = $("#gstin").val();
            var partygst = $("#partygst").val();
            gst = gst.substring(0, 2);
            var tamnt = $("#tvalue").val();
            partygst = partygst.substring(0, 2);

            if (gst == partygst) {
                $("#cgst").val((tamnt * ((x.value) / 100)) / 2)
                if (utarr.indexOf(gst) >= 0) {//Utgst
                    $("#utgst").val($("#cgst").val())
                    $("#sgst").val('')
                } else {//sgst
                    $("#sgst").val($("#cgst").val())
                    $("#utgst").val('')
                }
                $("#igst").val('')
            }
            else {                   //Igst--------------------------
                $("#igst").val((tamnt * (x.value)) / 100);
                $("#cgst").val('')
                $("#sgst").val('')
                $("#utgst").val('')

            }

            var tamnt1 = (($("#tvalue").val()) * (x.value / 100));
            var x4 = parseFloat(tamnt) + parseFloat(tamnt1);
            if ($("#cess").val() != '') {
                x4 = parseFloat(x4) + parseFloat($("#cess").val())
            }
            $("#total").val(x4);
            $("#htotal").val(x4);

        } else {
            $("#cgst").val('')
            $("#igst").val('')
            $("#sgst").val('')
            $("#utgst").val('')
            $("#total").val('')

        }

    } else {

        alert("Please Check T.Value and Prty GST.!!!")
        x.value = "";
    }


}

function RatePerUnit(x) {
    debugger;

    if ($("#qty").val() != '') {
        var qty = $("#qty").val();
        if (x.value != '') {
            var rpu = x.value;
            $("#tvalue").val(qty * rpu);
        } else {
            $("#tvalue").val('');
        }
    }
    else {
        alert('Please add quantity!')
        x.value = '';
    }
}
function QTYEntered(x) {
    if (x.value != '') {
        if ($("#rpu").val() != '') {
            var rpu = $("#rpu").val();
            $("#tvalue").val(x.value * rpu);
        } else {
            $("#tvalue").val('');
        }
    }
}
function CessEntered(x) {
    debugger
    var total = $("#htotal").val()
    if (x.value != '') {
        var sum = parseFloat(total) + parseFloat(x.value)
        $("#total").val(sum);
    }
    else {
        $("#total").val($("#htotal").val())
    }
}
function partygsttyped(x) {
    debugger
    if ($("#doctype").val() == 'Sale') {
        if (x.value != '') {
            gst = x.value.substring(0, 2);
            $.ajax({
                type: "POST",
                url: "/IP/GetState",
                contentType: "application/json; charset=utf-8",
                data: '{"code":"' + gst + '"}',
                dataType: "json",
                success: function (result) {
                    $("#Place").val(result)
                },
                error: function () {

                }
            });

        }
    } else if ($("#doctype").val() != 'Purchase') {
        $("#Place").val('')
    }
}
function Doctypechanged(x) {
    debugger
    if (x.value == "Purchase") {
        var statename = "";
        var gst = $("#gstin").val();
        gst = gst.substring(0, 2);
        $.ajax({
            type: "POST",
            url: "/IP/GetState",
            contentType: "application/json; charset=utf-8",
            data: '{"code":"' + gst + '"}',
            dataType: "json",
            success: function (result) {
                $("#Place").val(result)
            },
            error: function () {

            }
        });


    }
    else if (x.value == "Sale" && $("#partygst").val() != '') {
        var gst = $("#partygst").val();
        gst = gst.substring(0, 2);
        $.ajax({
            type: "POST",
            url: "/IP/GetState",
            contentType: "application/json; charset=utf-8",
            data: '{"code":"' + gst + '"}',
            dataType: "json",
            success: function (result) {
                $("#Place").val(result)
            },
            error: function () {
            }
        });

    }
    else {
        $("#Place").val("")
    }
}

