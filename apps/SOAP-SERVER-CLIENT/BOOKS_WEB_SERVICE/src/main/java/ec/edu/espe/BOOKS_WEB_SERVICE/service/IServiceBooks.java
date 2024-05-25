package ec.edu.espe.BOOKS_WEB_SERVICE.service;
import ec.edu.espe.BOOKS_WEB_SERVICE.model.ModelBooks;

import java.util.List;

public interface IServiceBooks {
    public List<ModelBooks> findAll();
    public ModelBooks find(Long id);
     public ModelBooks save(ModelBooks modelBooks);
    public ModelBooks update(ModelBooks modelBooks);

    public void delete(Long id);

}
