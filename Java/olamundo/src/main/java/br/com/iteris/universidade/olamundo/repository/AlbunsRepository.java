package br.com.iteris.universidade.olamundo.repository;

import br.com.iteris.universidade.olamundo.domain.entity.Album;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface AlbunsRepository extends JpaRepository<Album, Integer> {
    Optional<Album> findByNomeContaining(String nome);

    @Query(
            nativeQuery = true,
            value = "SELECT * FROM album WHERE (:nome IS NULL OR nome = :nome) AND (:artista IS NULL OR artista = :artista)",
            countQuery = "SELECT count(*) FROM album WHERE (:nome IS NULL OR nome = :nome) AND (:artista IS NULL OR artista = :artista)"
    )
    Page<Album> listarComFiltroNativo(@Param("nome") String nome, @Param("artista") String artista, Pageable pageable);

    @Query("SELECT a FROM Album a WHERE (:nome IS NULL OR a.nome = :nome) AND (:artista IS NULL OR a.artista = :artista)")
    Page<Album> listarComFiltro(@Param("nome") String nome, @Param("artista") String artista, Pageable pageable);

}