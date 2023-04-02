$(document).ready(function () {

    //// Get States by Country ID
    //$('#CountryId').change(function () {
    //    $.ajax({
    //        type: "get",
    //        url: "/Common/GetStatesByCountryId",
    //        data: { countryId: $('#CountryId').val() },
    //        datatype: "json",
    //        traditional: true,
    //        success: function (data) {
    //            var state = "<select id='StateId'>";
    //            state = state + '<option value="">Select State</option>';
    //            for (var i = 0; i < data.length; i++) {
    //                state = state + '<option value=' + data[i].id + '>' + data[i].name + '</option>';
    //            }
    //            state = state + '</select>';
    //            $('#StateId').html(state);
    //        }
    //    });
    //});

    //// Get Cities by State ID
    //$('#StateId').change(function () {
    //    $.ajax({
    //        type: "get",
    //        url: "/Common/GetCitiesByStateId",
    //        data: { stateId: $('#StateId').val() },
    //        datatype: "json",
    //        traditional: true,
    //        success: function (data) {
    //            var city = "<select id='CityId'>";
    //            city = city + '<option value="">Select City</option>';
    //            for (var i = 0; i < data.length; i++) {
    //                city = city + '<option value=' + data[i].id + '>' + data[i].name + '</option>';
    //            }
    //            city = city + '</select>';
    //            $('#CityId').html(city);
    //        }
    //    });
    //});

    // Dropdown

    $('body').on('change', '#CountryId', function () {
        var CountryId = $(this).val();
        LoadState(CountryId);
    })

    $('body').on('change', '#StateId', function () {
        var StateId = $(this).val();
        LoadCity(StateId);
    })
/*    $('body').on('change', '#CourseId', function () {
        var CourseId = $(this).val();
        LoadBatch(CourseId);
    })*/

    //Checkbox Checked
    var $ssc = $("#Ssc");
    var $hsc = $("#Hsc");
    var $bsc = $("#Bsc");
    var $msc = $("#Msc");

    $hsc.on("click", function () {
        var anyChecked = $hsc.is(":checked");
        $ssc.prop("checked", anyChecked);
    });
    $bsc.on("click", function () {
        var anyChecked = $bsc.is(":checked");
        $ssc.prop("checked", anyChecked);
        $hsc.prop("checked", anyChecked);
    });
    $msc.on("click", function () {
        var anyChecked = $msc.is(":checked");
        $ssc.prop("checked", anyChecked);
        $hsc.prop("checked", anyChecked);
        $bsc.prop("checked", anyChecked);
    });

});

function LoadState(CountryId) {
    var $state = $('#StateId');
    $.ajax({
        type: "get",
        url: "/Common/GetStatesByCountryId",
        data: { countryId: CountryId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            var state = "<select id='StateId'>";
            state = state + '<option value="">Select State</option>';
            for (var i = 0; i < data.length; i++) {
                state = state + '<option value=' + data[i].id + '>' + data[i].name + '</option>';
            }
            state = state + '</select>';
            $('#StateId').html(state);
        }
    });
}

function LoadCity(StateId) {
    var $city = $('#CityId');
    $.ajax({
        type: "get",
        url: "/Common/GetCitiesByStateId",
        data: { stateId: StateId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            var city = "<select id='CityId'>";
            city = city + '<option value="">Select City</option>';
            for (var i = 0; i < data.length; i++) {
                city = city + '<option value=' + data[i].id + '>' + data[i].name + '</option>';
            }
            city = city + '</select>';
            $('#CityId').html(city);
        }
    });
}

/*function LoadBatch(CourseId) {
    var $batch = $('#BatchId');
    $.ajax({
        type: "get",
        url: "/Common/GetBatchByCourse",
        data: { courseId: CourseId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            var batch = "<select id='BatchId'>";
            batch = batch + '<option value="">Select Batch Name</option>';
            for (var i = 0; i < data.length; i++) {
                batch = batch + '<option value=' + data[i].id + '>' + data[i].batchName + '</option>';
            }
            batch = batch + '</select>';
            $('#BatchId').html(batch);
        }
    });
}
*/