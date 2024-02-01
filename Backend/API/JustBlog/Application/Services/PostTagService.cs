using Application.Contracts;
using Application.Dtos;
using Application.PaginationHelper;
using AutoMapper;
using System.Collections.ObjectModel;

namespace Application.Services
{
    public class PostTagService : IPostTagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private int PageSize = 5;

        public PostTagService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> DeletePostTag(Guid postId)
        {
            try
            {
                return await _unitOfWork.PostTagMapRepository.DeleteAllRelatedTags(postId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<Collection<TagViewDto>> GetTagsByPostId(Guid postId, int page)
        {
            try
            {
                var tags = _mapper.Map<ICollection<TagViewDto>>(await _unitOfWork.PostTagMapRepository.GetTagsForPost(postId));
                var paginationHelper = new PaginationHelper<TagViewDto>();
                var tagsPagination = paginationHelper.Paginate(tags, page, PageSize);
                return _mapper.Map<Collection<TagViewDto>>(tagsPagination);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<bool> LinkTagsToPost(Guid postId, ICollection<Guid> tagIds)
        {
            try
            {
                return await _unitOfWork.PostTagMapRepository.LinkTagsToPost(postId, tagIds);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<bool> UnlinkTagFromPost(Guid postId, Guid tagId)
        {
            try
            {
                return await _unitOfWork.PostTagMapRepository.UnlinkTagFromPost(postId, tagId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<bool> UpdatePostTags(Guid postId, List<Guid> tagIds)
        {
            try
            {
                return await _unitOfWork.PostTagMapRepository.UpdatePostTags(postId, tagIds);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}