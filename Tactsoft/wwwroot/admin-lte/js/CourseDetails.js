$(document).ready(function () {

    $('body').on('change', '#CourseId', function () {
        var courseId = $(this).val();
        LoadBatch(courseId)
        console.log(courseId)
    })
});

function LoadBatch(CourseId) {
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
function LoadBatch(CourseId) {
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