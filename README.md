# EntityFramework-Minimal
EntityFramework-Minimal

IEnumerable vs IQueryable
-------------------------

#Using  IEnumerable : make select WITHOUT WHERE and after make the final filter
IEnumerable<Category> categories1 = _context.Categories;
IEnumerable<Category> enumerableFilter1 = categories1.Where(field => field.CategoryGroupId == 10);
List<Category> list1 = enumerableFilter1.ToList(); //here execute sql
##efective sql executed: SELECT "c"."Id", "c"."CategoryGroupId", "c"."Name" FROM "Categories" AS "c"


#Using IQueryable : make a select with WHERE (correct way)
IQueryable<Category> categories2 = _context.Categories;
IEnumerable<Category> enumerableFilter2 = categories2.Where(field => field.CategoryGroupId == 10);
List<Category> list2 = enumerableFilter2.ToList(); //here execute sql
##efective sql executed: SELECT "c"."Id", "c"."CategoryGroupId", "c"."Name" FROM "Categories" AS "c" WHERE "c"."CategoryGroupId" = 10
