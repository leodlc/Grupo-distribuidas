package ec.edu.espe.BOOKS_WEB_SERVICE.controller;

import ec.edu.espe.BOOKS_WEB_SERVICE.model.ModelBooks;
import ec.edu.espe.BOOKS_WEB_SERVICE.service.IServiceBooks;
import io.spring.guides.gs_producing_web_service.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

import java.util.List;
import java.util.stream.Collectors;

@Endpoint
public class BooksController {
    private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

    @Autowired
    private IServiceBooks libroService;

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "getLibroRequest")
    @ResponsePayload
    public GetLibroResponse getLibro(@RequestPayload GetLibroRequest request) {
        GetLibroResponse response = new GetLibroResponse();
        ModelBooks libro = libroService.find(request.getId());
        response.setLibro(convertToLibro(libro));
        return response;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "createLibroRequest")
    @ResponsePayload
    public CreateLibroResponse createLibro(@RequestPayload CreateLibroRequest request) {
        CreateLibroResponse response = new CreateLibroResponse();
        ModelBooks modelBooks = convertToModelBooks(request.getLibro());
        libroService.save(modelBooks);
        response.setStatus("Libro creado exitosamente");
        return response;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "updateLibroRequest")
    @ResponsePayload
    public UpdateLibroResponse updateLibro(@RequestPayload UpdateLibroRequest request) {
        UpdateLibroResponse response = new UpdateLibroResponse();
        ModelBooks modelBooks = convertToModelBooks(request.getLibro());
        libroService.save(modelBooks); // Asegúrate de que el método update esté implementado en el servicio
        response.setStatus("Libro actualizado exitosamente");
        return response;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "deleteLibroRequest")
    @ResponsePayload
    public DeleteLibroResponse deleteLibro(@RequestPayload DeleteLibroRequest request) {
        DeleteLibroResponse response = new DeleteLibroResponse();
        libroService.delete(request.getId());
        response.setStatus("Libro eliminado exitosamente");
        return response;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "getAllLibrosRequest")
    @ResponsePayload
    public GetAllLibrosResponse getAllLibros(@RequestPayload GetAllLibrosRequest request) {
        List<ModelBooks> modelBooksList = libroService.findAll();
        List<Libro> libros = modelBooksList.stream()
                .map(this::convertToLibro) // Utiliza la referencia correcta al método
                .collect(Collectors.toList());

        GetAllLibrosResponse response = new GetAllLibrosResponse();
        response.getLibros().addAll(libros);
        return response;
    }

    private Libro convertToLibro(ModelBooks modelBooks) {
        Libro libro = new Libro();
        libro.setId(modelBooks.getId());
        libro.setTitulo(modelBooks.getTitulo());
        libro.setAutor(modelBooks.getAutor());
        libro.setEditorial(modelBooks.getEditorial());
        libro.setAnoPublicacion(modelBooks.getAnopublicacion());
        libro.setIsbn(modelBooks.getIsbn());
        return libro;
    }

    private ModelBooks convertToModelBooks(Libro libro) {
        ModelBooks modelBooks = new ModelBooks();
        modelBooks.setId(libro.getId());
        modelBooks.setTitulo(libro.getTitulo());
        modelBooks.setAutor(libro.getAutor());
        modelBooks.setEditorial(libro.getEditorial());
        modelBooks.setAnopublicacion(libro.getAnoPublicacion());
        modelBooks.setIsbn(libro.getIsbn());
        return modelBooks;
    }
}
