package br.com.iteris.universidade.catalogovideos.repository;

import br.com.iteris.universidade.catalogovideos.domain.entity.Responsavel;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ResponsaveisRepository  extends JpaRepository<Responsavel, Integer> {
}
