using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VemProFutApi.Domain.Enuns;

namespace VemProFutApi.Domain.Entities
{
    [Table("peladeiro")]
    public class Peladeiro
    {
        public Peladeiro()
        {
            //Construtor padrao: Inicializa as coleções para evitar referências nulas
            Partidas = new List<Partida>();
            Cartoes = new List<Cartao>();
            Futs = new List<Fut>();
            Administra = new List<Fut>();
            Editores = new List<Editor>();
            GolsPeladeiro = new List<GolPartida>();
            Banimentos = new List<Banimento>();
        }

        [Key]
        [Column("id_peladeiro")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("nome_peladeiro"), Required, StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Column("email"), Required, StringLength(80)]
        public string Email { get; set; } = string.Empty;

        [Column("apelido_peladeiro"), Required, StringLength(30)]
        public string Apelido { get; set; } = string.Empty;

        [Column("descricao_peladeiro"), Required, StringLength(100)]
        public string Descricao { get; set; } = string.Empty;

        [Column("whatsapp_peladeiro"), Required, StringLength(15)]
        public string WhatsApp { get; set; } = string.Empty;

        [Column("pe_dominante_peladeiro"), Required, StringLength(10)]
        public PeDominante PeDominante { get; set; }

        [Column("fk_historico_peladeiro")]
        public long? HistoricoPeladeiroId { get; set; } // FK

        [ForeignKey("HistoricoPeladeiroId")]
        public HistoricoPeladeiro? HistoricoPeladeiro { get; set; }

        public ICollection<Partida> Partidas { get; set; }
        public ICollection<Cartao> Cartoes { get; set; }
        public ICollection<Fut> Futs { get; set; }
        public ICollection<Fut> Administra { get; set; }
        public ICollection<Editor> Editores { get; set; }
        public ICollection<GolPartida> GolsPeladeiro { get; set; }
        public ICollection<Banimento> Banimentos { get; set; }

        [Column("auth_provider"), StringLength(50)]
        public string AuthProvider { get; set; }

        [Column("foto_url"), StringLength(255)]
        public string FotoUrl { get; set; }

        // Metódos Helpers para manter a consistencia nas relacoes
        public void AddPartida(Partida partida)
        {
            Partidas.Add(partida);
            partida.AddPeladeiro(this);
        }

        public void AddFut(Fut fut)
        {
            Futs.Add(fut);
            fut.AddPeladeiro(this);
        }

        public void AddBanimento(Banimento banimento)
        {
            Banimentos.Add(banimento);
            banimento.AddPeladeiro(this);
        }

    }
}
