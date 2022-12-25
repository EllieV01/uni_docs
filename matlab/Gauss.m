%Ввод матрицы коэффициентов и матрицы свободных членов 
B = input('Enter a matrix of coefficient\n');
b = input('Enter the response matrix\n');

%Проверка размерности матриц
if (size(B, 1) ~= size(b, 1))
    disp('Input Error')
else
    %Составление расширенной матрицы и прямой ход метода Гаусса
    A = [B, b];
    n = size(B, 1);
    m = size(B, 2);
    for jt=1:m
        for it=jt:n
            if abs(A(jt, jt)) <= 10^(-5)
                k = it+1;
                while (k<=n) && (abs(A(k, jt)) <= 10^(-5))
                    k = k+1;
                end
                if k<=n
                    c = A(it, :);
                    A(it, :) = A(k, :);
                    A(k, :) = c;
                end
            else
                if (it~=jt) && (abs(A(it, jt)) > 10^(-5))
                    A(it, jt:end) = A(it, jt:end) - A(it, jt)/A(jt, jt)*A(jt, jt:end);
                end
            end
        end   
    end
    
    %Преобразования строк с одинаковым количеством нулей в начале
    it = 1;
    jt = 1;
    key = 0;
    m = size(A, 2);
    while (it < n)&&(jt<=m)
        if (abs(A(it, jt))> 10^(-5)) && (key == 0)
            it = it + 1;
        else
            key = 0;
            while (jt + 1 <= m) && (abs(A(it, jt)) <= 10^(-5))
                jt = jt + 1;
            end
            if abs(A(it+1, jt)) > 10^(-5)
                A(it, jt:end) = A(it, jt:end) - A(it, jt)/A(it+1, jt)*A(it+1, jt:end);
                dj = jt;
                while (dj+1<=m)&&(abs(A(it, dj+1)) <= 10^(-5))
                    dj = dj+1;                        
                end
                di = it;
                while (di+1<=n)&&(abs(A(di+1, dj)) > 10^(-5))
                    di = di + 1;
                end
                if (di~=it) && (dj ~= jt)
                    c = A(it, :);
                    F = cat (1, A(1:di, :), c);
                    F = cat (1, F, A(di+1:end, :));
                    F(it, :) = [];
                    A = F;
                    key = 1;
                    jt = jt - 1;
                end
            end                       
        end
        if (jt == m)
            jt = jt +1;
        end
    end
    
    %Нахождение и удаление нулевых строк
    while find(all(abs(A)<=10^(-5), 2))
        A(all(abs(A)<=10^(-5), 2), :) = [];
    end
    
    %Проверка совместимости матриц
    if find(all(abs(A(:, 1:m-1))<= 10^(-5), 2))
    	disp('No solutions')
    else
        n = size(A, 1);
        %Обратный ход для квадратной матрицы
        if (n+1)==m
            X = zeros(n, 1);
            for z=n:-1:1
                X(z, 1) = A(z, z+1)/A(z, z);
                if z>1
                    A(1:(z-1), z) = A(1:z-1, z)*(-X(z, 1))+A(1:z-1,z+1);
                end
            end
            %Вывод ответа для квадратной матрицы
            disp(X)
        else
            %Обратный ход для прямоугольной матрицы
            jt = 1;
            for it=1:size(A, 1)
                while abs(A(it, jt))<=10^(-5)
                    jt = jt+1;
                end
                A(it, :) = A(it, :)/A(it, jt);
            end
            B = A(:, 1:size(A, 2)-1);
            b = A(:, size(A, 2));
            X  = sym('x',[1 size(B, 2)]);
            A = [X.*B, b];
            for it=size(A, 1):-1:1
                kt = 1;
                while A(it, kt) == 0
                    kt = kt +1;
                end
                X(1, kt) = 0;
                for jt = kt+1:size(A, 2)
                    if jt == size(A, 2)
                        X(1,kt) = X(1,kt) + A(it, jt);
                    else
                        X(1,kt) = X(1,kt) - A(it, jt);
                    end
                end
                A = [X.*B, b];
            end
            %Вывод ответа для прямоугольной матрицы
            disp(X)
        end
    end    
end