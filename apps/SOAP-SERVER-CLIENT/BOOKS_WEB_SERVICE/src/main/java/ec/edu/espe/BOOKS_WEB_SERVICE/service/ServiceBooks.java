package ec.edu.espe.BOOKS_WEB_SERVICE.service;

import ec.edu.espe.BOOKS_WEB_SERVICE.dao.DaoBooks;
import ec.edu.espe.BOOKS_WEB_SERVICE.model.ModelBooks;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.beans.BeanInfo;
import java.beans.Introspector;
import java.beans.PropertyDescriptor;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

@Service
public class ServiceBooks implements IServiceBooks {
    @Autowired
    private DaoBooks daoBooks;
    @Override
    public ModelBooks find(Long id){
        return daoBooks.findByIdEnable(id).orElse(new ModelBooks());
    }
    @Override
    public List<ModelBooks> findAll(){
        return daoBooks.findAllEnable().orElseGet(ArrayList::new);

    }
@Override
 public ModelBooks save(ModelBooks modelBooks) {
        return daoBooks.save(modelBooks);
    }
    @Override
    public ModelBooks update(ModelBooks modelBooks){
        ModelBooks existingEntity=daoBooks.findByIdEnable(modelBooks.getId()).orElse(null);
        if(existingEntity!=null){
            BeanUtils.copyProperties(modelBooks,existingEntity,getNullPropertyNames(modelBooks));
        }
        return existingEntity;
    }
    private String[] getNullPropertyNames(Object source) {
        try {
            final BeanInfo beanInfo = Introspector.getBeanInfo(source.getClass());
            final PropertyDescriptor[] propertyDescriptors = beanInfo.getPropertyDescriptors();
            final Set<String> emptyNames = new HashSet<>();
            for (PropertyDescriptor propertyDescriptor : propertyDescriptors) {
                final Object propertyValue = propertyDescriptor.getReadMethod().invoke(source);
                if (propertyValue == null) {
                    emptyNames.add(propertyDescriptor.getName());
                }
            }
            String[] result = new String[emptyNames.size()];
            return emptyNames.toArray(result);
        } catch (Exception e) {
            return new String[0];
        }
    }

    @Override
    public void delete(Long id){
        daoBooks.deleteById(id);
    }
}
