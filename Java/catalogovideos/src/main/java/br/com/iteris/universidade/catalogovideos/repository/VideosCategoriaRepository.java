package br.com.iteris.universidade.catalogovideos.repository;

import br.com.iteris.universidade.catalogovideos.domain.entity.VideoCategoria;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface VideosCategoriaRepository  extends JpaRepository<VideoCategoria, Integer> {
}
