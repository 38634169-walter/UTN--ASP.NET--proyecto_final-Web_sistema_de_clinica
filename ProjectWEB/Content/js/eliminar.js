// JavaScript source code
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

        window.location.href = "https://es.stackoverflow.com/questions/228182/redireccionar-a-una-p%c3%a1gina-en-un-sweetalert";

        Swal.fire({
        })
    }
})