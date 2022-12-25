clear all;
format long;
a = pi/2;
b = 2*atan(sqrt(5));
n = 10;
h = (b-a)/n;
x = zeros(1, n+1);
y = zeros(1, n+1);
y01 = zeros(1, n);
y02 = zeros(1, n);
y03 = zeros(1, n);
F = zeros(1, n+1);
d1 = zeros(1, n);
d2 = zeros(1, n);
d3 = zeros(1, n);
i_i = zeros(n+1, 1);

%Построение сетки
k = a;
i_i(1, 1) = 0;
for p = 1:(n+1)
    x(1, p) = k;
    y(1, p) = 1/(3+2*cos(k));
    F(1, p) = 2/sqrt(5)*atan((tan(k/2))/sqrt(5))- 2/sqrt(5)*atan((tan(a/2))/sqrt(5));
    k = k+h;
end

%Конечно-разностный аналог и погрешность
k = a;
y01(1, 1) = y(1, 1)*h;
y02(1, 1) = y(1, 2)*h;
y03(1, 1) = (y(1, 2)+ y(1, 1))/2*h;
d1(1, 1) = abs(F(1, 2) - y01(1, 1));
d2(1, 1) = abs(F(1, 2) - y02(1, 1));
d3(1, 1) = abs(F(1, 2) - y03(1, 1));
for p = 2:n
    y01(1, p) = y01(1, p-1)+ y(1, p)*h;
    y02(1, p) = y02(1, p-1)+ y(1, p+1)*h;
    y03(1, p) = y03(1, p-1)+ (y(1, p+1)+ y(1, p))*h/2;
    d1(1, p) = abs(F(1, p+1) - y01(1, p));
    d2(1, p) = abs(F(1, p+1) - y02(1, p));
    d3(1, p) = abs(F(1, p+1) - y03(1, p));
    k = k + h;
    i_i(p+1, 1) = i_i(p, 1) + 1;
end


%Наибольшее погрешности
dm1 = max(d1);
dm2 = max(d2);
dm3 = max(d3);

%Построение графиков
X = a:1/1000:b;
Y = 2./sqrt(5).*atan((tan(X./2))./sqrt(5)) - 2/sqrt(5)*atan((tan(a/2))/sqrt(5));
x2 = x(1, 2:n+1);


figure
subplot(2,2,1);
plot(X, Y, "-", x2, y01, "-.", x2, y02, "-.", x2, y03, "-.");
grid on
title('Первообразная первого интеграла')
xlabel('X')
ylabel('Y')
legend({'Аналитическое решение', 'МЛП', 'МПП', 'МТ'}, 'Location', 'northwest');

subplot(2,2,2);
plot(x2, d1);
grid on
str = {'h = ' + string(h),'Δ^m = ' + string(dm1)};
text(2.25, 0.004, str);
title('Погрешность метода левых прямоугольников')
xlabel('X')
ylabel("Y")

subplot(2,2,3);
plot(x2, d2);
grid on
str = {'h = ' + string(h),'Δ^m = ' + string(dm2)};
text(2.25, 0.004, str);
title('Погрешность метода правых прямоугольников')
xlabel('X')
ylabel("Y")

subplot(2,2,4);
plot(x2, d3);
grid on
str = {'h = ' + string(h),'Δ^m = ' + string(dm3)};
text(2.25, 0.00006, str);
title('Погрешность метода трапеций')
xlabel('X')
ylabel("Y")


% xi = x';
% fi = y';
% Fi = F';
% yi_1 = y01';
% yi_2 = y02';
% yi_3 = y03';
% Delta1 = d1';
% Delta2 = d2';
% Delta3 = d3';
% 
% T = table(i_i, xi, fi, Fi, yi_1, yi_2, yi_3, Delta1, Delta2, Delta3);
% writetable(T,'Integral1.xlsx');