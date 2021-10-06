package br.com.iteris.universidade.catalogovideos.repository;
import br.com.iteris.universidade.catalogovideos.domain.entity.Categoria;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;


@Repository
public interface CategoriasRepository  extends JpaRepository<Categoria, Integer>{
}
