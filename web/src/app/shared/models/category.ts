export type Category = {
  id: string;
  categoryName: string;
  icon?: string;
  parentCategoryId?: string;
  createdAt: string;
  updatedAt: string;
  subCategories: Category[];
}
