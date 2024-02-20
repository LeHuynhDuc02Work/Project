var courseApi = "http://localhost:3000/course";

function Start() {
    getCourses(renderCourses);
    handleFormCreate();
}

Start();    

function getCourses(callback) {
    fetch(courseApi)
        .then(function(response) {
            return response.json();
        })
        .then(callback);
}

function renderCourses(courses) {
    var listCoursesBlock = document.querySelector("#list-courses");
    var htmls = courses.map(function(course) {
        return `
            <li class="course-id-${course.id}">
                <h4>${course.name}</h4>
                <p>${course.description}</p>
                <input type="button" onclick="handleDelete('${course.id}')" value="Delete"/>
            </li>
        `;
    });

    listCoursesBlock.innerHTML = htmls.join('');
}

function handleFormCreate() {
    var createBtn = document.querySelector('.Create');
    createBtn.onclick = function() {
        var name = document.querySelector('input[name="name"]').value;
        var description = document.querySelector('input[name="description"]').value;
        var formData = {
             name: name,
             description: description
         };

         handleCreate(formData, function() {
             getCourses(renderCourses);
         });
    };
}

function handleCreate(data, callback) {
    var option = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            //'Content-Type': 'application/x-www-form-urlencoded'
          },
        body: JSON.stringify(data),
      }
    fetch(courseApi, option)
      .then(function(response) {
        return response.json();
      })
      .then(callback);
}

function handleDelete(id) {
    console.log(id);
    var option = {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
            //'Content-Type': 'application/x-www-form-urlencoded'
          },
      }
    fetch(courseApi + "/" + id, option) 
      .then(function() {
        var nodeDelete = document.querySelector(".course-id-" + id);
        nodeDelete.remove();
      });
}

