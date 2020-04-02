using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Match.GroupManagement.Business.Models;
using Match.GroupManagement.Web.Models;

namespace Match.GroupManagement.Web.Mappers
{
    public static class GroupMappings
    {
        public static GroupViewModel ToViewModel(this Group model)
        {
            return model != null ? new GroupViewModel { Id = model.Id, Name = model.Name } : null;
        }

        public static Group ToServiceModel(this GroupViewModel model)
        {
            return model != null ? new Group { Id = model.Id, Name = model.Name } : null;
        }

        public static IReadOnlyCollection<GroupViewModel> ToViewModel(this IReadOnlyCollection<Group> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<GroupViewModel>();
            }

            var groups = new GroupViewModel[models.Count];

            int i = 0;
            foreach(var model in models)
            {
                groups[i] = model.ToViewModel();
            }

            return new ReadOnlyCollection<GroupViewModel>(groups);
        }
    }
}
