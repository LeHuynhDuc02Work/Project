using Application.Contracts;
using Application.Dtos;
using Application.PaginationHelper;
using AutoMapper;
using Core;
using System.Collections.ObjectModel;

namespace Application.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private int PageSize = 3;
        public TagService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TagViewDto> CreateTag(TagDto tagCreate)
        {
            try
            {
                var tagMap = _mapper.Map<Tag>(tagCreate);
                if (tagCreate != null)
                {
                    await _unitOfWork.TagRepository.Create(tagMap);
                    await _unitOfWork.TagRepository.SaveChange();
                }
                return _mapper.Map<TagViewDto>(tagMap);
                ;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<bool> DeleteTag(Guid tagId)
        {
            try
            {
                var tag = _unitOfWork.TagRepository.GetTagById(tagId);
                _unitOfWork.TagRepository.Delete(_mapper.Map<Tag>(tag));
                return await _unitOfWork.TagRepository.SaveChange(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<ICollection<TagViewDto>> GetAll(int page)
        {
            try
            {
                var tags = _mapper.Map<Collection<TagViewDto>>(await _unitOfWork.TagRepository.GetAll());
                var Pagination = new PaginationHelper<TagViewDto>();
                var tagsPagination = Pagination.Paginate(tags, page, PageSize);
                return tagsPagination;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<TagViewDto> GetTagById(Guid tagId)
        {
            try
            {
                return _mapper.Map<TagViewDto>(await _unitOfWork.TagRepository.GetTagById(tagId));
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<TagViewDto> UpdateTag(Guid tagId, TagDto tagUpdate)
        {
            try
            {
                var tag = await _unitOfWork.TagRepository.GetTagById(tagId);
                if (tag != null && tagUpdate != null)
                {
                    tag.Name = tagUpdate.Name;
                    tag.Description = tagUpdate.Description;
                    tag.UrlSlug = tagUpdate.UrlSlug;

                    _unitOfWork.TagRepository.Update(tag);
                    await _unitOfWork.TagRepository.SaveChange();
                }

                var tagView = _mapper.Map<TagViewDto>(tag);
                return tagView;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}