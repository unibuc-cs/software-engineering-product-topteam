using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.NotificareRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.NotificareService
{
	public class NotificareService : INotificareService
	{
		private readonly INotificareRepository _notificareRepository;
		private readonly IMapper _mapper;

		public NotificareService(INotificareRepository notificareRepository, IMapper mapper)
		{
			_notificareRepository = notificareRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<NotificareDTO>> GetAllNotificationsAsync()
		{
			var notifications = await _notificareRepository.GetAllNotificationsAsync();
			return _mapper.Map<IEnumerable<NotificareDTO>>(notifications);
		}

		public async Task<Notificare> GetNotificationByIdAsync(int id)
		{
			return await _notificareRepository.GetNotificationByIdAsync(id);
		}

		public async Task<bool> AddNotificationAsync(NotificareDTO notificareDto)
		{
			var notificare = _mapper.Map<Notificare>(notificareDto);
			return (await _notificareRepository.AddNotificationAsync(notificare));
		}

		public async Task UpdateNotificationAsync(int id, NotificareDTO notificareDto)
		{
			var notificare = await _notificareRepository.GetNotificationByIdAsync(id);
			_mapper.Map(notificareDto, notificare);
			await _notificareRepository.UpdateNotificationAsync(notificare);
		}

		public async Task DeleteNotificationAsync(int id)
		{
			await _notificareRepository.DeleteNotificationAsync(id);
		}
	}
}
