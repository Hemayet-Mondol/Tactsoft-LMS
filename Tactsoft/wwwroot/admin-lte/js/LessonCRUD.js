

//Lesson Modal Popup
var AddLesson = function () {
    var url = "/Lesson/Create";
    $('#titleMediumModal').html("Add New Lesson");
    loadMediumModal(url);
    console.log("Hello I am working");
};

//Student Modal Popup
/*var AddTrainer = function () {
    var url = "/Trainer/Create";
    $('#titleMediumModal').html("Add New Trainer");
    loadMediumModal(url);
    console.log("Hello I am working");
};*/

/*let AddTrainer = () => {
    var url = "/Trainer/Create";
    $('#titleMediumModal').html("Add New Trainer");
    loadMediumModal(url);
}*/

var EditLesson = function (id) {
    var url = "/Lesson/Edit?id=" + id;
    $('#titleMediumModal').html("Update Lesson Information");
    loadMediumModal(url);
};

var LessonDetails = function (id) {
    var url = "/Lesson/Details?id=" + id;
    $('#titleMediumModal').html("Lesson Details");
    loadMediumModal(url);
};

var DeleteLesson = function (id) {
    Swal.fire({
        title: 'Do you want to delete this item?',
        type: 'warning',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "POST",
                url: "/Lesson/Delete?id=" + id,
                success: function (result) {
                    var message = "Lesson has been deleted successfully";
                    Swal.fire({
                        title: message,
                        text: 'Deleted!',
                        onAfterClose: () => {
                            window.reload();
                        }
                    });
                }
            });
        }
    });
};

var loadMediumModal = function (url) {
    $("#MediumModalDiv").load(url, function () {
        $("#MediumModal").modal("show");
        $("#Name").focus();
    });
};




/*
var AddTr = function () {
    var url = "/Trainer/Create";
    $('#titleMediumModal').html("Add New Student");
    loadMediumModal(url);
};






var TrainerDetails = function (id) {
    var url = "/Trainer/Details?id=" + id;
    $('#titleMediumModal').html("Trainer Details");
    loadMediumModal(url);
};


var loadMediumModal = function (url) {
    $("#MediumModalDiv").load(url, function () {
        $("#MediumModal").modal("show");
        $("#Name").focus();
    });
};*/