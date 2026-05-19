using SLMS.Dto.SocialNetwork.Comments;

namespace SLMS.Application.Services
{
    public static class CommentTreeBuilder
    {
        public static List<CommentDto> BuildTree(List<CommentDto> comments)
        {
            var lookup = comments.ToDictionary(x => x.Id);
            List<CommentDto> roots = new();
            foreach (var item in comments)
            {
                item.ChildComments.Clear();
            }
            foreach (var comment in comments)
            {
                if (comment.ParentId == null)
                {
                    roots.Add(comment);
                }
                else if (lookup.TryGetValue(comment.ParentId.Value, out var parent))
                {
                    parent.ChildComments ??= new List<CommentDto>();
                    parent.ChildComments.Add(comment);
                }
            }

            return roots;
        }
    }

}
