$("#EditCourseForm").validate({
    debug: false,
    ignore: [],
    rules: {
        CourseName: {
            required:true
        }
    },
    errorElement: "p",
    messages: {
        CourseName: {
            required:"Please enter course name"
        }
    }
});

var _element;
$(document).on("click", ".delete-item-modal", function () {
    var Id = $(this).data('id');
    $(".item-id").val(Id);

    _element = $(this);
});

function Delete()
{
    var Id = $(".item-id").val();

    $.ajax({
        url: "Courses/Delete",
        type: 'Post',
        data: { Id: Id },
        success: function (result) {
            if (result.success == true) {
                $("#exampleModal").modal("hide");
                _element.parent().parent().remove();
            }
          
        }
    });

}



$(document).on("click", ".approved", function () {
    var Id = $(this).prev(".user-id").val();

    var str;
    if (this.checked)
        str = "Are you sure you want to approve this user?";
    else
        str = "Are you sure that you want to reject this user?";

    $("#exampleModal").modal('show');
    $(".modal-paragraph").text(str);
    $(".is-approve").val(this.checked);
    $(".item-id").val(Id);
});

function Approve() {
  var isApproved =  $(".is-approve").val();
  var Id = $(".item-id").val();
  $.ajax({
      url: "/Students/Approve",
      type: "POST",
      data: {
          isApproved: isApproved,
          Id: Id
      },
      success: function (result) {
          $("#exampleModal").modal('hide');
      },
      error: function () {
          alert("error");
      }
  });

}
$(document).on("change", ".course-ddl", function () {

    var courseId = $(this).val();
    var itemId = $(this).parent().parent().find(".user-id").val();

    $("#exampleModal2").modal("show");

    $(".course-id").val(courseId);
    $(".item-id").val(itemId);
});

function changeCourse() {
    var courseId = $(".course-id").val();
    var itemId = $(".item-id").val();

    $.ajax({
        url: "/students/changeCourse",
        type: "POST",
        data: {
            courseId: courseId,
            itemId: itemId
        },
        success: function (result) {
            if (result.success == true)
                $("#exampleModal2").modal("hide");
            else
                alert("error");
        },
        error: function () {
            alert("error");
        }
    })
}