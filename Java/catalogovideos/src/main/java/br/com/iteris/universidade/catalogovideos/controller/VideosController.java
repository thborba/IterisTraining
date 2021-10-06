package br.com.iteris.universidade.catalogovideos.controller;

import br.com.iteris.universidade.catalogovideos.domain.dto.VideoCreateRequest;
import br.com.iteris.universidade.catalogovideos.domain.dto.VideoResponse;
import br.com.iteris.universidade.catalogovideos.domain.dto.VideoUpdateRequest;
import br.com.iteris.universidade.catalogovideos.domain.entity.Video;
import br.com.iteris.universidade.catalogovideos.service.VideosService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;

@RestController
public class VideosController {

    private final VideosService service;

    public VideosController(VideosService service) {
        this.service = service;
    }

    @GetMapping(value = "api/videos/listar")
    public ResponseEntity<List<VideoResponse>> listar() {
        var listaDeVideos = service.listar();
        return ResponseEntity.ok(listaDeVideos);
    }

    @GetMapping(value = "api/videos/{id}")
    public ResponseEntity<VideoResponse> buscarPorId(@PathVariable Integer id) {
        var videoResponse = service.buscarPorId(id);
        return ResponseEntity.ok(videoResponse);
    }
    @PostMapping(value = "api/videos")
    public ResponseEntity<VideoResponse> criarVideo(@RequestBody @Valid VideoCreateRequest video) {
        var videoResponse = service.criarVideo(video);
        return ResponseEntity.ok(videoResponse);
    }

    @PutMapping(value = "api/tarefas/{idVideo}/atualizarUrl")
    public ResponseEntity<VideoResponse> atualizarPrioridade(
            @PathVariable Integer idVideo,
            @RequestBody @Valid VideoUpdateRequest videoUpdateRequest) {
        var video = service.atualizarUrl(idVideo, videoUpdateRequest);
        return ResponseEntity.ok(video);
    }

}
