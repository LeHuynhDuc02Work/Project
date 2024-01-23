using Application.Contracts;
using Application.Dtos;
using Application.PaginationHelper;
using AutoMapper;
using Core;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private int PageSize = 3;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PostViewDto> CreatePost(PostDto postCreate)
        {
            try
            {
                var postMap = new Post();
                if (postCreate != null)
                {
                    postMap = _mapper.Map<Post>(postCreate);
                    postMap.Id = Guid.NewGuid();
                    postMap.PostedOn = DateTime.Now;
                    postMap.Modified = DateTime.Now;
                    await _unitOfWork.PostRepository.Create(postMap);
                    await _unitOfWork.PostRepository.SaveChange();
                }

                return _mapper.Map<PostViewDto>(postMap);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<bool> DeletePost(Guid postId)
        {
            try
            {
                var post = _unitOfWork.PostRepository.GetPostById(postId);
                var postDelete = _mapper.Map<Post>(post);
                _unitOfWork.PostRepository.Delete(postDelete);
                return await _unitOfWork.PostRepository.SaveChange();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<ICollection<PostViewDto>> GetAll(string keyWord, int page)
        {
            try
            {
                var posts = _mapper.Map<ICollection<PostViewDto>>(await _unitOfWork.PostRepository.GetAll(keyWord));
                var Pagination = new PaginationHelper<PostViewDto>();
                var postsPagination = Pagination.Paginate(posts, page, PageSize);
                return postsPagination;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<PostViewDto> GetPostById(Guid postId)
        {
            try
            {
                return _mapper.Map<PostViewDto>(await _unitOfWork.PostRepository.GetPostById(postId));
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<PostViewDto> UpdatePost(Guid postId, PostDto postUpdate)
        {
            try
            {
                var postMap = _mapper.Map<Post>(_unitOfWork.PostRepository.GetPostById(postId));
                if (postUpdate != null && postMap != null)
                {
                    postMap.Title = postUpdate.Title;
                    postMap.Description = postUpdate.Description;
                    postMap.ShortDescription = postUpdate.ShortDescription;
                    postMap.Meta = postUpdate.Meta;
                    postMap.UrlSlug = postUpdate.UrlSlug;
                    postMap.Published = postUpdate.Published;
                    postMap.CategoryId = postUpdate.CategoryId;
                    postMap.Modified = DateTime.Now;
                    _unitOfWork.PostRepository.Update(postMap);
                    await _unitOfWork.PostRepository.SaveChange();
                }

                var postView = _mapper.Map<PostViewDto>(postMap);
                return postView;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}