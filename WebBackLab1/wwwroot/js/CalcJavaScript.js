function press(val) {
    ($('#calcform')).method = "post";
    var First = ($('#First')).val();
    var Second = ($('#Second')).val();
    if (parseInt(First) && parseInt(Second)) {
        $(function () {
            $(document).ready(function () {
                $('.CalcMenu').remove();
            });
        });
        $('<h1 class="Title">Result</h1>').replaceAll('h1');
    }
    $.post()
}

