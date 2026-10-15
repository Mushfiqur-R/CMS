using BAL.dto.parcel;
using Domain.Entities;

namespace BAL.Interfaces
{
    public interface IParcelService
    {
        Task<List<Parcel>> GetAllParcelsAsync();
        Task<Parcel?> GetParcelByTrackingNumberAsync(string trackingNumber);
        Task<CreateParcelDto> CreateParcelAsync(CreateParcelDto dto);
        Task UpdateParcelStatusAsync(int parcelId, ParcelStatus status, string? location, string? remarks, int changedByUserId);
    }
}
