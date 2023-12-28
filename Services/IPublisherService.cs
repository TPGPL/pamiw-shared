﻿using PamiwShared.Models;

namespace PamiwShared.Services;

public interface IPublisherService
{
    Task<ServiceResponse<List<Publisher>>> GetPublishersAsync();
    Task<ServiceResponse<Publisher>> GetPublisherAsync(int id);
    Task<ServiceResponse<Publisher>> CreatePublisherAsync(Publisher publisher);
    Task<ServiceResponse<Publisher>> UpdatePublisherAsync(int id, Publisher publisher);
    Task<ServiceResponse<Publisher>> DeletePublisherAsync(int id);
}
