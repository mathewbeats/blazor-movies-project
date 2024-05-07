// Funciones para mostrar notificaciones con Toastr
window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful", { timeOut: 10000 });
    } else if (type === "error") {
        toastr.error(message, "Operation Failed", { timeOut: 10000 });
    }
};


// Función para inicializar el carrusel de Bootstrap
window.initializeCarousel = function () {
    $('.carousel').carousel({
        interval: 3000,
        wrap: true
    });
};

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success Notification',
            message,
            'success'
        );
    }
    if (type === "error") {
        Swal.fire(
            'Error Notification',
            message,
            'error'
        );
    }
}

function MostrarModalConfirmacionBorrado() {
    $('#modalConfirmacionBorrado').modal('show');
}

function OcultarModalConfirmacionBorrado() {
    $('#modalConfirmacionBorrado').modal('hide');
}
