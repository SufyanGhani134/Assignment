$(document).ready(function () {
  
    var allStudents;

  function fetchAllStudents() {
    $.ajax({
      method: "GET",
      url: "http://localhost:62879/GetAllSudents",
      dataType: "json",
      success: function (data) {
        allStudents = data;
        displayStudents(allStudents)
      },
      error: function (error) {
        console.log(error);
      },
    });
  }

  function displayStudents(allStudents) {
    $("#main").empty();
    for (let i = 0; i < allStudents.length; i++) {
      $("#main").append(studentCard(allStudents[i]));
    }
  }

  function studentCard(student) {
    return ` <div class="studentCard"> 
    <h3>Students Info</h3>
    <p>First Name: <span>${student.FirstName}</span></p>
    <p>Last Name: <span>${student.LastName}</span></p>
    <p>Age: <span>${student.Age}</span></p>
    <p>Course: <span>${student.Course}</span></p>
    </div>`
  }

  fetchAllStudents();

//   $("#searchInput").on("keyup", fetchStudentByName())
//  function fetchStudentByName(){
//     let text = $("#searcInput").val();
//     $.ajax({
//         method: "GET",
//         url: `http://localhost:62879/getstudentsbyname?text = ${text}`,
//         dataType: "json",
//         success: function (data) {
//           console.log(data)
//         },
//         error: function (error) {
//           console.log(error);
//         },
//       });
//   }
});
