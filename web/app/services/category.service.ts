import axios from 'axios';

import { ICategory, ICreateCategory } from '@/app/types/category.type';

const instance = axios.create({
  baseURL: `${process.env.apiUrl}/categories`,
  headers: {
    'Content-Type': 'application/json'
  }
})

export const CategoryService = {

  async getAll() {
    return instance.get<ICategory[]>('')
  },
  
  async get(id: string) {
    return instance.get<ICategory>(`/${id}`)
  },

  async create(data: ICreateCategory) {
    instance.post('', data)
  },

  async update(data: ICategory) {
    instance.put(`/${data.id}`, data)
  },

  async delete(id: string) {
    instance.delete(`/${id}`)
  }
}