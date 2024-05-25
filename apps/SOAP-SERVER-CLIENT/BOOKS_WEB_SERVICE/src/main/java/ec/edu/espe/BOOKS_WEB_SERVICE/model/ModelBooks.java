package ec.edu.espe.BOOKS_WEB_SERVICE.model;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.Data;

@Data
@Entity
@Table(name = "libros", schema = "appsdistribuidas")
public class ModelBooks {

    @Id
    @Column(name = "ID")
    private Long id;

    @Column(name = "TITULO")
    private String titulo;

    @Column(name = "AUTOR")
    private String autor;

    @Column(name = "EDITORIAL")
    private String editorial;

    @Column(name = "ANOPUBLICACION")
    private Long  anopublicacion;
    @Column(name = "ISBN")
    private String isbn;
}
