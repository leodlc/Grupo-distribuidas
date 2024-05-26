package ec.edu.espe.BOOKS_WEB_SERVICE.model;

import jakarta.persistence.*;
import lombok.Data;

@Data
@Entity
@Table(name = "libros", schema = "appsdistribuidas")
public class ModelBooks {

    @Id
    @GeneratedValue(generator = "libros_Sequence",strategy = GenerationType.SEQUENCE)
    @SequenceGenerator(schema = "appsdistribuidas",allocationSize = 1,name="libros_Sequence",sequenceName = "libross")
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
