using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases;

public class TagUseCase : ITagUseCase
{
    private readonly ITagRepository _tagRepository;

    public TagUseCase(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public IEnumerable<Tag> GetAllTags()
    {
        return _tagRepository.GetAll();
    }
    
    public void CreateTag(Tag tag)
    {
        _tagRepository.Add(tag);
    }
}