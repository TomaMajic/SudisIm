using FluentNHibernate.Mapping;
using SudisIm.Model.Models;

namespace SudisIm.DAL.Mappings
{
    public class NotificationMap : ClassMap<Notification>
    {
        public NotificationMap()
        {
            Id(c => c.Id).GeneratedBy.Native();
            Map(c => c.IsOpened);
            Map(c => c.Text);
            References(c => c.Referee);
            References(c => c.Game);
        }
    }
}
