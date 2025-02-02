import { FC, memo, useContext, useEffect } from "react";
import { SubmitHandler, useForm } from "react-hook-form";

import { manufacturerPageData } from "./manufacturerPage.data";
import { IManufacturer, IManufacturerField } from "@/app/types/manufacturer.type";

import { Box, Grid } from "@mui/material";
import { useUpdateManufacturer } from "@/app/hooks/manufacturer/useUpdateManufacturer";
import RightSubmitButton from "@/app/components/shared/button/submitButton/RightSubmitButton";
import FormInput from "@/app/components/shared/formFields/formInput/FormInput";
import Products from "@/app/components/ui/products/Products";
import UploadImage from "@/app/components/shared/button/uploadImage/UploadImage";
import { ManufacturerContext } from "@/app/providers/manufacturerContextProvider";
import RightDeleteButton from "../../shared/button/deleteButton/RightDeleteButton";


const AdminManufacturerPage: FC<IManufacturer> = memo(props => {
  const {setCurrentManufacturer} = useContext(ManufacturerContext)
  const { products, id} = props

  useEffect(() => {
    setCurrentManufacturer(id)
  }, [])

  const { isLoading, updateManufacturer } =
    useUpdateManufacturer(manufacturerPageData.defaultValues);

  const { handleSubmit, control } = useForm<IManufacturer>({
    defaultValues: props,
  });

  const onSubmit: SubmitHandler<IManufacturer> = async (
    data: IManufacturer
  ) => {
    await updateManufacturer({...props, ...data});
  };

  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Grid container sx={{ mb: 2 }}>
          <Grid item xs={12} md={5} sx={{mb: 2}}>
            <UploadImage />
          </Grid>
          <Grid item xs={12} md={7}>
            <Grid container spacing={2}>
              {manufacturerPageData.fields.map(({name, rows, xs, md, required}: IManufacturerField) => (
                <Grid item key={name} xs={xs} md={md}>
                  <FormInput
                    defaultValue={props[name]}
                    control={control}
                    name={name}
                    required={required}
                    rows={rows}
                  />
                </Grid>
              ))}
            </Grid>
            <RightSubmitButton disabled={isLoading} />
            
          </Grid>
        </Grid>
      </form>

      <RightDeleteButton id={props.id} elementType='manufacturer' />

        <Box sx={{ borderTop: "1px solid #ccc", pt: 2, mt: 1 }}>
          <Products
            products={products}
            manufacturer={id}
          />
        </Box>
      
    </>
  )
});

export default AdminManufacturerPage;
