export type Category = {
  id: string;
  categoryName: string;
  icon?: string;
  parentCategoryId?: string;
  productCount: number;
  createdAt: string;
  updatedAt: string;
  subCategories: Category[];
}

export type AddCategory ={
  categoryName: string;
  icon?: string;
  parentCategoryId?: string;
}
