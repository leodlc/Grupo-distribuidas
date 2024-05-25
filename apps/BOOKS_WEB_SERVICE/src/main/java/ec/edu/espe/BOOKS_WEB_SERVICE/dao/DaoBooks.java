package ec.edu.espe.BOOKS_WEB_SERVICE.dao;

import ec.edu.espe.BOOKS_WEB_SERVICE.model.ModelBooks;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;

import java.util.List;
import java.util.Optional;

public interface DaoBooks extends CrudRepository<ModelBooks, Long>{
    @Query(value = "SELECT u FROM ModelBooks u ")
    public Optional<List<ModelBooks>> findAllEnable();

    @Query(value = "SELECT u FROM ModelBooks u WHERE u.id = :id")
    public Optional<ModelBooks> findByIdEnable(Long id);
}
