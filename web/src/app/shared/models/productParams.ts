export class productParams {
  defaultPageSize: number = 5;
  brand: string[] = [];
  category: string[] = [];
  sort: string = 'dateDesc';
  pageSize: number = this.defaultPageSize;
  pageIndex: number = 1;
  search: string = '';

}
