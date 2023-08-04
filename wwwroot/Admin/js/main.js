let itemDeleteBtns = document.querySelectorAll(".item-delete");
itemDeleteBtns.forEach(btn => btn.addEventListener("click", function (e) {
    e.preventDefault();

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            let url = btn.getAttribute("href"); 

            fetch(url)
                .then(response => {
                    if (response.status == 200) {
                        window.location.reload(true);
                    } else {
                        alert("The item you want to delete was not found!")
                    }
                })
            
        }
    })


//}))

//let sil = document.querySelectorAll(".emin");

//sil.forEach(btn => btn.addEventListener("click", function (e) {
//    console.log("hbchdvj")

//})