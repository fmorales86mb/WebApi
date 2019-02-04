// Primero tengo que instalar el knockoutjs
// Tengo que registrar el archivo js en el BundleConfig
// Tengo que agregar la referencia en el cshtml

//----------------- ViewModel -----------------

var AuthorViewModel = function () {
    var self = this;
    var uri = 'api/Author/';
    var id;
    self.name = ko.observable();

    function GetAuthor() {
        $.ajax({
            url: 'api/Author/1',
            type: 'GET',
            //data: data,
            //data: function (data) {
            //    self.name(data);
            //},
            success: function (info) {
                console.log(info);
            },
        })
    }

    function getAuthorName() {
        GetAuthor().done(function (data) {
            self.name(data);
        });
    }

    getAuthorName();
    //GetAuthor();
}

ko.applyBindings(new AuthorViewModel()); // no es ok es ko!!!!















/*
//----------------- Listas y colecciones -----------------

// función que me genera los elementos con los parámetros que le paso.
function DetalleLibro(autor, initialLibro) {
    var self = this;
    self.autor = autor;
    self.libro = ko.observable(initialLibro);
}

// ViewModel
function LibreriaViewModel() {
    var self = this;

    // Datos iniciales
    self.datosLibros = [
        { titulo: "El Martín Fierro", anio: 1872 },
        { titulo: "Don Quijote de la Mancha", anio: 1615 },
        { titulo: "La Divina Comedia", anio: 1308 }
    ];

    // Creo los items usando la función implementada 
    self.libros = ko.observableArray([
        new DetalleLibro("José Hernández", self.datosLibros[0]),
        new DetalleLibro("Miguel de Cervantes", self.datosLibros[1]),
        new DetalleLibro("Dante Alighieri", self.datosLibros[2]),
    ]);

    self.addLibro = function () {
        self.libros.push(new DetalleLibro("", self.datosLibros[0]));
    }
}

ko.applyBindings(new LibreriaViewModel());

-------------- HTML

<div class="row">
    <h3>Listas y collecciones.</h3>

    <table>
        <thead>
            <tr>
                <th> Título </th>
                <th> Autor </th>
                <th> Año </th>
            </tr>
        </thead>
        @* libros es un array de "self" de DetalleLibro *@
        @* foreach is part of a family of control flow bindings that includes foreach, if, ifnot, and with *@
        <tbody data-bind="foreach: libros">
            <tr>
                @* Las propiedades de libro (titulo y anio) se acceden llamando a libro como función. Ej: libro().titulo *@
                <td data-bind="text: libro().titulo"></td>
                <td data-bind="text: autor"></td>
                <td data-bind="text: libro().anio"></td>
            </tr>
        </tbody>
    </table>
    <p></p>
    <p>Cantidad de Libros: <strong data-bind="text: libros().length"></strong></p>
    <button data-bind="click: addLibro">Agregar Libro</button>
</div>

*/


//----------------- Intro -----------------

//var AppViewModel = function () {
//    //this.nombre = "fede";
//    this.nombre = ko.observable("Federico");
//    this.apellido = ko.observable("Morales");

//    this.fullName = ko.computed(function () {
//        return this.nombre() + " " + this.apellido();
//    }, this);

//    this.capitalizeNombre = function () {
//        var currentValue = this.nombre(); // Tomo el valor actual
//        this.nombre(currentValue.toUpperCase()); // Reescribo el valor original
        
//    };
//}

//ko.applyBindings(new AppViewModel());


//      HTML

//<div class="row">
//    <h3>Intro</h3>
//    <p>Nombre: <strong data-bind="text: nombre"></strong></p>
//    <p>Apellido: <strong data-bind="text: apellido"></strong></p>
//    <p>Nombre: <input data-bind="value: nombre" /></p>
//    <p>Nombre y Apellido: <strong data-bind="text: fullName"></strong></p>
//    <button data-bind="click: capitalizeNombre">Mayuscula</button>
//</div> 

