using AutoMapper;
using backend_MT.Data;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using System.Net;

namespace backend_MT.Helpers
{
	public class MapperProfile : Profile
	{
		private readonly ApplicationDbContext _context;

		public MapperProfile(ApplicationDbContext context)
		{
			_context = context;

			CreateMap <Curs, CursDTO>();
			CreateMap <CursDTO, Curs>();

			CreateMap <Disponibilitate, DisponibilitateDTO>();
			CreateMap <DisponibilitateDTO, Disponibilitate>();

			CreateMap <Feedback, FeedbackDTO>();
			CreateMap <FeedbackDTO, Feedback>();

			CreateMap <Grupa, GrupaDTO>();
			CreateMap <GrupaDTO, Grupa>();

			CreateMap <Material, MaterialDTO > ();
			CreateMap <MaterialDTO, Material>();

			CreateMap <Mesaj, MesajDTO > ();
			CreateMap <MesajDTO, Mesaj>();

			CreateMap <Notificare, NotificareDTO > ();
			CreateMap <NotificareDTO, Notificare>();

			CreateMap <Plata, PlataDTO > ();
			CreateMap <PlataDTO, Plata>();

			CreateMap <RaspunsTema, RaspunsTemaDTO> ();
			CreateMap <RaspunsTemaDTO, RaspunsTema>();

			CreateMap<Sedinta, SedintaDTO > ();
			CreateMap <SedintaDTO, Sedinta>();

			CreateMap <Support, SupportDTO> ();
			CreateMap <SupportDTO, Support>();

			CreateMap <Tema, TemaDTO> ();
			CreateMap <TemaDTO, Tema>();
		}
	}
}
