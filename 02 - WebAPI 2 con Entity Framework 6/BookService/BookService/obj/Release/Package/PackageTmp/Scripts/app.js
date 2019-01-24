
//En Knockout, la clase observable permite el enlace de datos.
//Cuando se cambia el contenido de un objeto observable, el objeto observable notifica a todos los controles enlazados a datos,
//    por lo que pueden actualizar a sí mismos. (El observableArray clase es la versión de la matriz de observable.)

var ViewModel = function () {
    var self = this;

    //Para empezar, nuestro modelo de vista tiene dos objetos observables:
    self.books = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable(); // detalle

    var booksUri = '/api/books/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    //El getAllBooks método realiza una llamada AJAX al obtener la lista de los libros en pantalla.
    //A continuación, inserta el resultado en el books matriz.
    function getAllBooks() {
        ajaxHelper(booksUri, 'GET').done(function (data) {
            self.books(data);
        });
    }
    
    // se carga el modelo detalle
    self.getBookDetail = function (item) {
        ajaxHelper(booksUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    // Fetch the initial data.
    getAllBooks();
};

//El ko.applyBindings método forma parte de la biblioteca Knockout.
//Toma el modelo de vista como un parámetro y establece el enlace de datos.
ko.applyBindings(new ViewModel());