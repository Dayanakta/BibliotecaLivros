using System.Collections.Generic;


namespace BibliotecaLivros.Domain.Models
{
    public class VolumeInfo
    {
        #region Dados Volume do livro
        /// <summary>
        /// Título do volume.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Legenda do volume.
        /// </summary>
        public string Subtitle { get; set; }
        /// <summary>
        /// Os nomes dos autores e / ou editores deste volume.
        /// </summary>
        public List<string> Authors { get; set; }
        /// <summary>
        /// Editora deste volume.
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// Uma sinopse do volume.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Número total de páginas.
        /// </summary>
        public int? PageCount { get; set; }
        /// <summary>
        /// Uma lista de categorias de assuntos, como "Ficção", "Suspense", etc.	
        /// </summary>
        public List<string> Categories { get; set; }
        /// <summary>
        /// Uma lista de links de imagens para todos os tamanhos disponíveis.
        /// </summary>
        public ImageLinks ImageLinks { get; set; }
        /// <summary>
        /// URL para visualizar este volume no site do Google Livros.	
        /// </summary>
        public string PreviewLink { get; set; }
        #endregion

        #region Construtores
        public VolumeInfo()
        {

        }
        #endregion
    }
}





