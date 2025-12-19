export type Review = {
  bookId: number;
  userId: number;
  user: {
    firstName: string;
    lastName: string;
  };
  rating: number;
  comment: string;
  datePosted: Date;
};
