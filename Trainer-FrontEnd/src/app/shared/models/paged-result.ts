export class PagedResult<T>{
    currentPage: number;
    itmesCount: number;
    pageSize: number;
    pagesCount: number;
    results: T[];
}