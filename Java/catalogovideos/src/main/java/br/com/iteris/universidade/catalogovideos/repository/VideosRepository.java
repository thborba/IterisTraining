package br.com.iteris.universidade.catalogovideos.repository;


import br.com.iteris.universidade.catalogovideos.domain.entity.Video;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface VideosRepository   extends JpaRepository<Video, Integer> {
}
