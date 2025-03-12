﻿namespace TQMS_Admin_Application.Features.LevelHierarchy.Command.UpdateLevelHierarchy
{
    public class UpdateLevelHierarchyCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid Level_Id { get; set; }
        public Guid Parent_Id { get; set; }
    }

    public class CreateLevelHierarchyCommandHandler(ILevelHierarchyRepository levelHierarchy,
       ILevelsRepository levelsRepository,
       ILevelHierarchyValidator levelHierarchyValidator) : IRequestHandler<UpdateLevelHierarchyCommand, Response<Guid>>
    {
        private readonly ILevelHierarchyRepository _levelHierarchy = levelHierarchy;
        private readonly ILevelHierarchyValidator _levelHierarchyValidator = levelHierarchyValidator;
        private readonly ILevelsRepository _levelsRepository = levelsRepository;


        public async Task<Response<Guid>> Handle(UpdateLevelHierarchyCommand request, CancellationToken cancellationToken)
        {
            var levels = await _levelsRepository.GetByIdLevelsAsync(request.Level_Id);
            if (levels == null)
                return new Response<Guid>(request.Level_Id, message: Message.branchNotFound);

            var LevelHierarchy = new TQMS_Admin_Domain.Entities.LevelHierarchy()
            {
                Id = request.Id,
                Name = request.Name,
                Level_Id = request.Level_Id,
                Parent_Id = request.Parent_Id,
                ModifiedBy = "System",
                ModifiedDate = DateTime.Now,
                IsActive = true
            };

            _levelHierarchyValidator.ValidateEntity(LevelHierarchy);
            await _levelHierarchy.AddLevelHierarchyAsync(LevelHierarchy);
            return new Response<Guid>(LevelHierarchy.Id, message: Message.levelHierarchyCreate);
        }
    }
}
