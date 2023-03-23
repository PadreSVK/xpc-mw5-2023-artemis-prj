import {FC, memo} from 'react'

import classNames from 'classnames'

import { AiFillStar } from 'react-icons/ai'

import styles from './rating.module.scss'

interface IProps {
    rate: number,
    description?: string,
    size?: string
}

const Rating: FC<IProps> = memo(({rate, description, size}) => {
    return (
        <div className={styles.rating}>
            <div className={styles.rating__rate}>
                <div className={classNames({
                    [styles.rating__stars]: true,
                    [styles.stars__small]: size === 'small',
                    [styles.stars__full]: size !== 'small'
                })}>
                    {renderStars()}
                </div>
                {size !== 'small' && (
                    <div className={styles.rating__value}>
                        ({rate})
                    </div>
                )}
            </div>
            {description && size !== 'small' && (
                <div className={styles.rating__description}>
                    {description}
                </div>
            )}
        </div>
    )


    function renderStars(): React.ReactNode[] {
        const stars: React.ReactNode[] = [];

        for (let i = 1; i <= 5; i++) {
            stars.push(
                <div key={`rating-${i}`} className={i <= Math.floor(rate) ? styles.gold : ''}>
                    <AiFillStar />
                </div>
            )
        }

        return stars;
    }
})

export default Rating